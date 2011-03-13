readContentsBrief: brevityFlag
	"Read the contents of the receiver's selected file, unless it is too long, in which case show just the first and last 1000 characters. Don't create a file if it doesn't already exist."

	| f fileSize first2000 |
	listIndex = 0 ifTrue: [^ self defaultContents].
	f _ directory oldFileOrNoneNamed: self fullName.
	f ifNil: [^ 'For some reason, this file cannot be read'].
	(brevityFlag not or: [(fileSize _ f size) <= 30000])
		ifTrue: [^ f contentsOfEntireFile].

	"if brevityFlag is true, don't display long files when first selected"
	first2000 _ f next: 2000.
	f close.
	^ 'File ''', fileName, ''' is ', fileSize printString, ' bytes long.
You may use the ''get'' command to read the entire file.

Here are the first 2000 characters...
------------------------------------------
', first2000 , '
------------------------------------------
... end of the first 2000 characters.'
