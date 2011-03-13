openInMVC
	| textView sendButton  |

	mvcWindow _ StandardSystemView new
		label: 'Mister Postman';
		minimumSize: 400@250;
		model: self.

	textView _ PluggableTextView
		on: self
		text: #messageText
		accept: #messageText:.
	textEditor _ textView controller.

	sendButton _ PluggableButtonView 
		on: self
		getState: nil
		action: #submit.
	sendButton label: 'Send'.
	sendButton borderWidth: 1.

	sendButton window: (1@1 extent: 398@38).
	mvcWindow addSubView: sendButton.

	textView window: (0@40 corner: 400@250).
	mvcWindow addSubView: textView below: sendButton.

	mvcWindow controller open.

		
