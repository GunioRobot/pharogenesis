announce: anAnnouncement
	self announcements add: anAnnouncement.
	self index: self announcements size.
	self changed: #announcements