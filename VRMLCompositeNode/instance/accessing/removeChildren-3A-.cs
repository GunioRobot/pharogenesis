removeChildren: childList
	self children: (self children reject:[:child| childList includes: child]).