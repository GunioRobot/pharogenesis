stampForm: stampForm for: aPickupButton
	"Install this form to stamp. Find its index.  Make a thumbnail."

	| which scale shrunkForm stampBtn mini |
	which _ pickupButtons indexOf: aPickupButton.
	which = 0 ifTrue: [which _ stampButtons indexOf: aPickupButton].
	stamps atWrap: which+start-1 put: stampForm.

	"Create the thumbnail"
	stampBtn _ stampButtons at: which.
	scale _ stampBtn width / (stampForm extent x max: stampForm extent y).
	scale _ scale min: 1.0.	"do not expand it"
	mini _ stampForm magnify: stampForm boundingBox by: scale smoothing: 1.
	shrunkForm _ mini class extent: stampBtn extent depth: stampForm depth.
	mini displayOn: shrunkForm at: (stampBtn extent - mini extent)//2.
	thumbnailPics atWrap: which+start-1 put: shrunkForm.
	stampBtn offImage: shrunkForm; onImage: shrunkForm; pressedImage: shrunkForm.
		"Emphasis is done by border of enclosing layoutMorph, not modifying image"

	(stamps indexOf: nil) = 0 ifTrue: ["Add an extra blank place"
		"Keep stamp we just installed in the same location!"
		start+which-1 > stamps size ifTrue: [start _ start + 1].
		stamps addLast: nil.
		thumbnailPics addLast: nil.
		self normalize].
