replace: oldString with: newString in: aString
	"Replace all occurances of oldString in the given string with newString."

	| target where |
	target _ aString.
	where _ 1.
	[(where _ target findString: oldString startingAt: where) = 0] whileFalse:
		[target _ target
					copyReplaceFrom: where
					to: where + oldString size - 1
					with: newString].
	^target