notifyOfChangedSelectorsOldDict: oldDictionaryOrNil newDict: newDictionaryOrNil
	| newCat |
	(oldDictionaryOrNil isNil and: [newDictionaryOrNil isNil])
		ifTrue: [^ self].
		
	oldDictionaryOrNil isNil ifTrue: [
	newDictionaryOrNil keysAndValuesDo: [:el :cat |
		self notifyOfChangedSelector: el from: nil to: cat].
		^ self.
	].

	newDictionaryOrNil isNil ifTrue: [
	oldDictionaryOrNil keysAndValuesDo: [:el :cat |
		self notifyOfChangedSelector: el from: cat to: nil].
		^ self.
	].
		
	oldDictionaryOrNil keysAndValuesDo: [:el :cat |
		newCat _ newDictionaryOrNil at: el.
		self notifyOfChangedSelector: el from: cat to: newCat.
	].