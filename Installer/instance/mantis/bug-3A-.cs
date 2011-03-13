bug: aBugNo

"
Installer mantis viewBug: 5639.
"
	| page text | 

	self setBug: aBugNo.
	
	page := self maPage.
 
	text := String streamContents: [ :str |	
			
		#('Bug ID' 'Category' 'Severity' 'Reproducibility' 'Date Submitted' 
			'Date Updated' 'Reporter' 'View Status' 'Handler' 
			'Priority' 'Resolution' 'Status' 'Product Version' 'Summary' 'Description' 'Additional Information' ) 
				do: [ :field |
						| f |
						f := self maRead: page field: field.
			str nextPutAll: f key; nextPutAll: ': '; nextPutAll: f value; cr.
		].
	
	str nextPutAll: 'Notes: '; cr.
		(self maReadNotes: page) do: [ :note | str nextPutAll: note; cr; cr ].
		
		str nextPutAll: 'Files: '; nextPutAll: self maFiles keys asArray printString.
	].
 	
^ text	
