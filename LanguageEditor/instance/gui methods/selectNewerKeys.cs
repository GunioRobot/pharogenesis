selectNewerKeys

	| translations index |
	self deselectAllTranslation.
	translations := self translations.
	newerKeys do: [:k |
		index := translations indexOf: k ifAbsent: [0].
		index > 0 ifTrue: [
			self selectedTranslationsAt: index put: true
		].
	].
