checkAndApplyUpdates: availableUpdate
	"SystemVersion checkAndApplyUpdates: nil"

	^(availableUpdate isNil
		or: [availableUpdate > SystemVersion current highestUpdate])
		ifTrue: [
			(self confirm: 'There are updates available. Do you want to install them now?')
				ifFalse: [^false].
			Utilities
				readServerUpdatesThrough: availableUpdate
				saveLocally: false
				updateImage: true.
			SmalltalkImage current snapshot: true andQuit: false.
			true]
		ifFalse: [false]