showComment: aComment
	| fileName |
	fileName := (ServerAction serverDirectory) , 'ShowComment.html'.
	^HTMLformatter evalEmbedded: (FileStream fileNamed: fileName) contentsOfEntireFile with: aComment.

