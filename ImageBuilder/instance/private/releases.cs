releases
	"Return all releases."
	^self packageSpecs
		collect: [:arr | (SMSqueakMap default packageWithId: arr first)
						releaseWithAutomaticVersionString: arr second]