addMVCMailSenderButtons: topView textView: mailTextView
	"Add some handy buttons to the mail sender window."

	| sendButton sendAndKeepButton doneButton |
	sendButton _
		PluggableButtonView new
			model: (Button new onAction:
					[mailTextView controller accept.
					 mailTextView controller controlTerminate.
					 Celeste postMessage: mailTextView model contents]);
			action: #turnOn;
			label: 'Send';
			window: (0@0 extent: 34@10);
			borderWidth: 1.
	sendAndKeepButton _
		PluggableButtonView new
			model: (Button new onAction:
					[mailTextView controller accept.
					 mailTextView controller controlTerminate.
					 Celeste postMessage: mailTextView model contents.
					 Celeste addMessageToInbox: mailTextView model contents]);
			action: #turnOn;
			label: 'Send&Keep';
			window: (0@0 extent: 33@10);
			borderWidth: 1.
	doneButton _
		PluggableButtonView new
			model: (Button new onAction: [topView controller close]);
			action: #turnOn;
			label: 'Done';
			window: (0@0 extent: 33@10);
			borderWidth: 1.
	topView
		addSubView: sendButton above: topView firstSubView;
		addSubView: sendAndKeepButton toRightOf: sendButton;
		addSubView: doneButton toRightOf: sendAndKeepButton.
