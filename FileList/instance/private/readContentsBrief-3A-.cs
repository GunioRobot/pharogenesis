readContentsBrief: brevityFlag
	"Read the contents of the receiver's selected file, unless it is too long, in which case show just the first 5000 characters. Don't create a file if it doesn't already exist."
	| f fileSize first5000 |

	brevityFlag ifTrue: [
		(directory isKindOf: ServerDirectory) ifTrue: [^ self readServerBrief]].
	f _ directory oldFileOrNoneNamed: self fullName.
	f ifNil: [^ 'For some reason, this file cannot be read'].
	(brevityFlag not or: [(fileSize _ f size) <= 100000]) ifTrue:
		[contents _ f contentsOfEntireFile.
		brevityState _ #fullFile.   "don't change till actually read"
		^ contents].

	"if brevityFlag is true, don't display long files when first selected"
	first5000 _ f next: 5000.
	f close.
	contents _ 'File ''', fileName, ''' is ', fileSize printString, ' bytes long.
You may use the ''get'' command to read the entire file.

Here are the first 5000 characters...
------------------------------------------
', first5000 , '
------------------------------------------
... end of the first 5000 characters.'.
	brevityState _ #briefFile.   "don't change till actually read"
	^ contents.
