/*var chatModel = new Vue({
    el: '#chat-conversation',
    data: {
        messages: []
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
        addMessage: function (message) {
            this.messages.push(message);
            $('#new-message').val('');

            this.$nextTick(function () {
                $('#chat-conversation').scrollTop($('#chat-conversation').scrollTop() + $('#chat-conversation').height() + 100);
            });
        }
    },
    computed: {
        sortedMessages: function () {
            this.messages.sort((a, b) => {
                return new Date(a.timestamp) - new Date(b.timestamp);
            });

            return this.messages;
        }
    }
});*/