updateFileList
	"Update my files list with file names in the current directory  
	that match the pattern.
	The pattern string may have embedded newlines or semicolons; these separate different patterns."
	| patterns |
	patterns _ OrderedCollection new.
	Cursor wait showWhile: [
	(pattern findTokens: (String with: Character cr with: Character lf with: $;))
		do: [ :each |
			(each includes: $*) | (each includes: $#)
					ifTrue: [ patterns add: each]
					ifFalse: [each isEmpty
										ifTrue: [ patterns add: '*']
										ifFalse: [ patterns add: '*' , each , '*']]].

	list _ self listForPatterns: patterns.
	listIndex _ 0.
	volListIndex _ volList size.
	fileName _ nil.
	contents _ ''.
	self changed: #volumeListIndex.
	self changed: #fileList.
	self updateButtonRow]