normalize
	"Correspondence between buttons and stamp forms has changed.  Make all thumbnails show up right."

	| shrunkForm |
	1 to: stampButtons size do: [:ind |
		shrunkForm _ thumbnailPics atWrap: ind+start-1.
		(stampButtons at: ind) offImage: shrunkForm; onImage: shrunkForm; 
			pressedImage: shrunkForm.	"later modify them"
		].