clear
	"wipe out all existing stamps"

	stamps _ OrderedCollection new: 16.
	thumbnailPics _ OrderedCollection new: 16.
	stampButtons do: [:each | 
		stamps addLast: nil.	"hold a space"
		thumbnailPics addLast: nil].
	start _ 1.
	self normalize.