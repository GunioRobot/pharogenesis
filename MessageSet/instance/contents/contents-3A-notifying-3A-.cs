contents: aString notifying: aController 
	"Compile the code in aString. Notify aController of any syntax errors. 
	Create an error if the category of the selected message is unknown. 
	Answer false if the compilation fails. Otherwise, if the compilation 
	created a new method, deselect the current selection. Then answer true."
	| category selector class oldSelector notice |
	messageListIndex = 0 ifTrue: [^ false].
	self setClassAndSelectorIn: [:class :oldSelector].
	category _ class organization categoryOfElement: oldSelector.
	selector _ class
				compile: aString
				classified: category
				notifying: aController.
	selector == nil ifTrue: [^false].
	selector == oldSelector ifFalse: [self messageListIndex: 0].
	notice _ class checkForPerform: selector in: aController.
	notice size = 0 ifFalse: ["insert the notice"
			aController notify: notice
				at: contents size + 1
				in: nil.
			self lock  "code is dirty"].
	^true