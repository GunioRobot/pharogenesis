editMessageCategories
	"Indicate to the receiver and its dependents that the message categories of 
	the selected class have been changed."

	self okToChange ifFalse: [^ self].
	classListIndex ~= 0
		ifTrue: 
			[self messageCategoryListIndex: 0.
			editSelection _ #editMessageCategories.
			self changed: #editMessageCategories.
			self contentsChanged]