split: aString by: splitChar
	| lines index nextIndex |
	lines := OrderedCollection new.
	index _ 1.
	[index <= aString size] whileTrue:[
		nextIndex _ aString 
						indexOf: splitChar 
						startingAt: index 
						ifAbsent:[aString size+1].
		lines add: (aString copyFrom: index to: nextIndex-1).
		index _ nextIndex+1].
	^lines