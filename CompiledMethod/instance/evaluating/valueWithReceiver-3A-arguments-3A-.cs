valueWithReceiver: aReceiver arguments: anArray 
	| selector |
	selector _ Symbol new.
	aReceiver class addSelector: selector withMethod: self.
	^ [aReceiver perform: selector withArguments: anArray]
		ensure: [aReceiver class removeSelectorSimply: selector]