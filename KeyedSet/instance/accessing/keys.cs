keys

	| keys |
	keys _ Set new.
	self keysDo: [:key | keys add: key].
	^ keys