(function () {
    
})();

const eventBus = new Vue();

/*var videoModel = new Vue({
    el: '#video-container',
    data: {
        chatOpen: false
    },
    created: function () {
        eventBus.$on('toggleChat', function (open) {
            this.chatOpen = open;
        });
    },
    computed: {
        videoSize: function () {
            return {
                'col-9': this.chatOpen,
                'col-12': !this.chatOpen
            }
        },
        chatSize: function () {
            return {
                'col-3': this.chatOpen,
                'col-0': !this.chatOpen
            }
        }
    }
});*/

var timerModel = new Vue({
    el: '#timer',
    data: {
        elapsed: 0,
        duration: '',
        interval: 1000
    },
    created: function () {
        setInterval(this.timerInterval, this.interval);
    },
    methods: {
        timerInterval: function () {
            this.elapsed += 1;
            this.formatDuration();
        },
        formatDuration: function () {
            var minutes = Math.round(this.elapsed / 60);
            var seconds = this.elapsed % 60;
            var formattedSeconds = seconds.toString();

            if (seconds < 10) {
                formattedSeconds = `0${seconds}`;
            }

            this.duration = `${minutes}:${formattedSeconds}`;
        }
    }
});

var userModel = new Vue({
    el: '#video-grid1',
    data: {
        users: [],
        avToggled: 0,
        localStream: null,
    },
    methods: {
        addUser: function (user) {
            var existing = this.users.find(x => x.userId == user.userId);

            if (!existing) {
                user.audioEnabled = true;
                user.videoEnabled = true;
                this.users.push(user);
            }
        },
        removeUser: function (userId) {
            var index = this.users.findIndex(x => x.userId == userId);

            if (index >= 0) {
                this.users.splice(index, 1);
            }
        },
        setUserStream: function (userId, stream) {
            this.$refs[`remote-video-${userId}`][0].srcObject = stream;

            var existing = this.users.find(x => x.userId == userId);

            if (existing) {
                existing.stream = stream;
            }
        },
        addScreenShareStream: function (userId, stream) {
            this.users.forEach(user => {
                if (user && user.peerConnection) {
                    var track = stream.getVideoTracks()[0];

                    if (track) {
                        user.peerConnection.addTrack(track, localStream);
                    }
                }
            });
        },
        toggleUserAudio: function (userId) {
            var existing = this.users.find(x => x.userId == userId);

            if (existing) {
                existing.audioEnabled = !existing.audioEnabled;
                existing.stream.getAudioTracks()[0].enabled = existing.audioEnabled;
                this.avToggled++;
                this.$forceUpdate();
            }
        },
        toggleUserVideo: function (userId) {
            var existing = this.users.find(x => x.userId == userId);

            if (existing) {
                existing.videoEnabled = !existing.videoEnabled;
                existing.stream.getVideoTracks()[0].enabled = existing.videoEnabled;
                this.avToggled++;
                this.$forceUpdate();
            }
        },
        getUsers: function () {
            return this.users;
        }
    }
});

var sidePanel = new Vue({
    el: '#side-column',
    data: {
        chatOpen: true,
        localStream: null,
        messages: []
    },
    created: function () {
        var model = this;

        eventBus.$on('toggleChat', function (open) {
            model.chatOpen = open;
        });
    },
    methods: {
        init: function () {
            var url = `/room/${room}/messages/${currentUserId}`;
            var model = this;

            $.get(url).then(function (response) {
                if (response && response.length > 0) {
                    response.forEach(m => {
                        model.messages.push(m);
                    });

                    setTimeout(function () {
                        $('#chat-conversation').scrollTop(response.length * 50);
                    }, 100);
                }
            });
        },
        setLocalStream: function (stream) {
            this.localStream = stream;
            this.$refs['local-video'].onmetadataloaded = () => {
                this.$refs['local-video'].play();
            };
            this.$refs['local-video'].srcObject = stream;
        },
        addMessage: function (message) {
            this.messages.push(message);
            $('#new-message').val('');

            this.$nextTick(function () {
                $('#chat-conversation').scrollTop($('#chat-conversation').scrollTop() + $('#chat-conversation').height() + 100);
            });
        }
    },
    computed: {
        chatSize: function () {
            return {
                'col-3': this.chatOpen,
                'col-0': !this.chatOpen
            }
        },
        sortedMessages: function () {
            var messages = this.messages.sort((a, b) => {
                return new Date(a.timestamp) - new Date(b.timestamp);
            });

            return messages;
        }
    },
});

var videoGridModel = new Vue({
    el: '#video-container',
    data: {
        users: [],
        displayName: '',
        sharingScreen: false,
        remoteSharingScreen: false,
        localStream: null,
        chatOpen: true
    },
    created: function () {
        var model = this;

        eventBus.$on('toggleChat', function (open) {
            model.chatOpen = open;
        });
    },
    computed: {
        videoSize: function () {
            return {
                'col-9': this.chatOpen,
                'col-12': !this.chatOpen
            }
        },
        chatSize: function () {
            return {
                'col-3': this.chatOpen,
                'col-0': !this.chatOpen
            }
        }
    },
    methods: {
        setLocalStream: function(stream) {
            //this.localStream = stream;
            //this.$refs['local-video-small'].srcObject = stream;
        },
        addUser: function (user) {
            var existing = this.users.find(x => x.userId == user.userId);

            if (!existing) {
                user.audioEnabled = true;
                user.videoEnabled = true;
                this.users.push(user);
            }
        },
        removeUser: function (userId) {
            var index = this.users.findIndex(x => x.userId == userId);

            if (index >= 0) {
                this.users.splice(index, 1);
            }
        },
        setUserStream: function (userId, stream) {
            this.$refs[`remote-video-${userId}`][0].srcObject = stream;

            var existing = this.users.find(x => x.userId == userId);

            if (existing) {
                existing.stream = stream;
            }
        },
        addScreenShareStream: function (userId, stream) {
            this.users.forEach(user => {
                if (user && user.peerConnection) {
                    var track = stream.getVideoTracks()[0];

                    if (track) {
                        user.peerConnection.addTrack(track, localStream);
                    }
                }
            });
        },
        toggleUserAudio: function (userId) {
            var existing = this.users.find(x => x.userId == userId);

            if (existing) {
                existing.audioEnabled = !existing.audioEnabled;
                existing.stream.getAudioTracks()[0].enabled = existing.audioEnabled;
                this.avToggled++;
                this.$forceUpdate();
            }
        },
        toggleUserVideo: function (userId) {
            var existing = this.users.find(x => x.userId == userId);

            if (existing) {
                existing.videoEnabled = !existing.videoEnabled;
                existing.stream.getVideoTracks()[0].enabled = existing.videoEnabled;
                this.avToggled++;
                this.$forceUpdate();
            }
        },
        getUsers: function () {
            return this.users;
        }

       /* addUser: function (user) {
            var existing = this.users.find(x => x.userId == user.userId);

            if (!existing) {
                this.users.push(user);
            }
        },
        removeUser: function (userId) {
            var index = this.users.findIndex(x => x.userId == userId);

            if (index >= 0) {
                this.users.splice(index, 1);
            }

            this.$nextTick(() => {
                this.users.forEach((user, i) => {
                    //$(`#remote-video-${user.userId}`)[0].srcObject = user.stream;
                });
            });
        }*/
    }
});

var videoControlsModel = new Vue({
    el: '#video-controls',
    data: {
        audioEnabled: true,
        videoEnabled: true,
        sharingScreen: false,
        chatOpen: false,
        screenShareConnections: []
    },
    computed: {
        videoSize: function () {
            return {
                'col-9': this.chatOpen,
                'col-12': !this.chatOpen
            }
        },
        chatSize: function () {
            return {
                'col-3': this.chatOpen,
                'col-0': !this.chatOpen
            }
        }
    },
    methods: {
        muteAudio: function () {
            if (localStream == null) {
                return;
            }

            this.audioEnabled = !this.audioEnabled;

            if (localStream.getAudioTracks().length > 0) {
                localStream.getAudioTracks()[0].enabled = this.audioEnabled;
            }
        },
        muteVideo: function () {
            if (localStream == null) {
                return;
            }

            this.videoEnabled = !this.videoEnabled;

            if (localStream.getVideoTracks().length > 0) {
                localStream.getVideoTracks()[0].enabled = this.videoEnabled;
            }
        },
        endCall: function () {
            window.location = `/Lobby/${room}`;
        },
        toggleChat: function () {
            this.chatOpen = !this.chatOpen;
            eventBus.$emit('toggleChat', this.chatOpen);
        },
        shareScreen: function () {
            var instance = this;

            if (screenStream == null) {
                var screenOptions = {
                    video: {
                        frameRate: 10
                    },
                    audio: false
                };

                navigator.mediaDevices.getDisplayMedia(screenOptions).then((stream) => {
                    instance.sharingScreen = true;
                    videoGridModel.sharingScreen = true;
                    screenStream = stream;
                    screenStream.getTracks()[0].onended = () => instance.screenShareEnded();

                    userModel.addScreenShareStream(currentUserId, stream);
                    $('#screen-video')[0].srcObject = stream;
                    $('#screen-video').css('display', 'block');

                    userModel.users.forEach(user => {
                        var screenConnection = initializePeerConnection(user.userId, true);
                        screenConnection.addStream(screenStream);
                        instance.screenShareConnections.push(screenConnection);

                        screenConnection.createOffer().then(offer => {
                            return screenConnection.setLocalDescription(offer);
                        }).then(() => {
                            var sdp = screenConnection.localDescription
                            sendOffer(sdp, user.userId, 'screen');
                        });
                    });
                });
            } else {
                screenStream.getTracks().forEach(track => track.stop())
                this.screenShareEnded();
            }
        },
        screenShareEnded: function () {
            this.sharingScreen = false
            videoGridModel.sharingScreen = false;
            screenStream = null;
            $('#screen-video')[0].srcObject = null;

            this.screenShareConnections.forEach(con => {
                con.close();
            });

            this.screenShareConnections.splice(0, this.screenShareConnections.length);
        }
    }
});