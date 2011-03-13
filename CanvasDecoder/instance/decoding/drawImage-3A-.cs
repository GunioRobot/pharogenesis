drawImage: command
	| image point sourceRect rule cacheID cacheNew previousImage |

	image := self class decodeImage: (command at: 2).
	point := self class decodePoint: (command at: 3).
	sourceRect := self class decodeRectangle: (command at: 4).
	rule := self class decodeInteger: (command at: 5).
	command size >= 7 ifTrue: [
		false ifTrue: [self showSpaceUsed].		"debugging"
		cacheID _ self class decodeInteger: (command at: 6).
		cacheNew _ (self class decodeInteger: (command at: 7)) = 1.
		cacheID > 0 ifTrue: [
			CachedForms ifNil: [CachedForms _ Array new: 100].
			cacheNew ifTrue: [
				CachedForms at: cacheID put: image
			] ifFalse: [
				previousImage _ CachedForms at: cacheID.
				image ifNil: [
					image _ previousImage
				] ifNotNil: [
					(previousImage notNil and: [image depth > 8]) ifTrue: [
						image _ previousImage addDeltasFrom: image.
					].
					CachedForms at: cacheID put: image
				].
			].
		].
	].
	self drawCommand: [ :c |
		c image: image  at: point  sourceRect: sourceRect rule: rule
	]