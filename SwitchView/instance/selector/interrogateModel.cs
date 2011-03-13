interrogateModel
	"Answer the result of sending the receiver's model the message created 
	from the receiver's selector and arguments."

	| aBrowser aChangeSorter |
	arguments size = 0
		ifTrue: [^model perform: selector]
		ifFalse: [^model perform: selector withArguments: arguments].

	false ifTrue: ["Selectors Performed"
		"Please list all selectors that could be args to the 
		perform: in this method.  Do this so senders will find
		this method as one of the places the selector is sent from."
		self listPerformSelectorsHere.		"tells the parser its here"

		aBrowser instanceMessagesIndicated.
		aBrowser classMessagesIndicated.
		aChangeSorter whatPolarity.
		].