readServerBrief
	| lString sizeStr fsize ff first5000 parts |
	"If file on server is known to be long, just read the beginning.  Cheat badly by reading the fileList string."

	listIndex = 0 ifTrue: [^ self].
	"Get size from file list entry"
	lString _ list at: listIndex.
	parts _ lString findTokens: '()'.
	sortMode = #name ifTrue: [sizeStr _ (parts second findTokens: ' ') third].
	sortMode = #date ifTrue: [sizeStr _ (parts first findTokens: ' ') third].
	sortMode = #size ifTrue: [sizeStr _ (parts first findTokens: ' ') first].
	fsize _ (sizeStr copyWithout: $,) asNumber.

	fsize <= 50000 ifTrue:
		[ff _ directory oldFileOrNoneNamed: self fullName.
		ff ifNil: [^ 'For some reason, this file cannot be read'].
		contents _ ff contentsOfEntireFile.
		brevityState _ #fullFile.   "don't change till actually read"
		^ contents].

	"if brevityFlag is true, don't display long files when first selected"
	first5000 _ directory getOnly: 3500 from: fileName.
	contents _ 'File ''', fileName, ''' is ', sizeStr, ' bytes long.
You may use the ''get'' command to read the entire file.

Here are the first 3500 characters...
------------------------------------------
', first5000 , '
------------------------------------------
... end of the first 3500 characters.'.
	brevityState _ #briefFile.   "don't change till actually read"
	^ contents.

