selectNewerKeys

	| translations index |
	self deselectAllTranslation.
	translations _ self translations.
	newerKeys do: [:k |
		index _ translations indexOf: k ifAbsent: [0].
		index > 0 ifTrue: [
			self selectedTranslationsAt: index put: true
		].
	].
