open
	| topView |
	self initialize.

	topView _ StandardSystemView new.
	topView model: self.
	topView label: self label.
	topView minimumSize: 360@360.
	self openView: topView.
	topView controller open		"Let the show begin"