readContentsBrief: brevityFlag
	"retrieve the contents from the external file unless it is too long"
	| f size newContents first1000 last1000 |
	f _ FileStream fileNamed: self fullName. 
	f == nil ifTrue:
		[^ 'For some reason, this file cannot be read'].
	(brevityFlag and: [(size _ f size) > 30000]) ifFalse: 
		[^ f contentsOfEntireFile].

	"Don't display long files at first.
	Composing the paragraph may take a long time."
	first1000 _ f next: 1000.
	f position: size - 1000.
	last1000 _ f next: 1000.
	f close.
	^ 'File ''' , fileName , ''' is ', size printString, ' bytes long.
You may use the ''get'' command to read the entire file.

Here are the first 1000 characters:
--------------------------------
' , first1000 , '

... and here are the last 1000 characters:
--------------------------------------
' , last1000