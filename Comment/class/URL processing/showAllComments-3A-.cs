showAllComments: aDictionaryOfCommentSpaces
	| fileName |
	fileName := (ServerAction serverDirectory) , 'ShowAllComments.html'.
	^HTMLformatter evalEmbedded: (FileStream fileNamed: fileName)
contentsOfEntireFile with: aDictionaryOfCommentSpaces

