contents: aString notifying: aController 
	"Compile the code in aString. Notify aController of any syntax errors. 
	Answer false if the compilation fails. Otherwise, if the compilation 
	created a new method, deselect the current selection. Then answer
true."
	| category selector class oldSelector |
	messageListIndex = 0 ifTrue: [^ false].
	self okayToAccept ifFalse: [^ false].
	self setClassAndSelectorIn: [:c :os | class_c.  oldSelector_os].
	category _ class organization categoryOfElement: oldSelector.
	selector _ class compile: aString
				classified: category
				notifying: aController.
	selector == nil ifTrue: [^ false].
	self noteAcceptanceOfCodeFor: selector.
	selector == oldSelector ifFalse:
		[self reformulateListNoting: selector].
	contents _ aString copy.
	self changed: #annotation.
	^ true