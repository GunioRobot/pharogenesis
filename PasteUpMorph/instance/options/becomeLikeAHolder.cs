becomeLikeAHolder
	(self autoLineLayout
			and: [self indicateCursor])
		ifTrue: [^ self inform: 'This view is ALREADY
behaving like a holder, which
is to say, it is set to indicate the
cursor and to have auto-line-layout.' translated].
	self behaveLikeHolder