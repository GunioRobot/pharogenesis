browseCommentOf: class
	| changeList |
	Cursor read showWhile:
		[changeList := self new scanVersionsOf: class.
	 	 changeList ifNil: [^ self inform: 'No versions available'].
		 self open: changeList name: 'Recent versions of ',class name,'''s comments' multiSelect: false ]
