isOld
	"Answer if I am installed and there also is a
	newer version available *regardless* if it is
	not published or not for this Squeak version.
	This is for people who want to experiment!"

	| installed |
	installed := map installedReleaseOf: self.
	^installed
		ifNil: [false]
		ifNotNil: [
			self releases anySatisfy: [:r |
				r newerThan: installed ]]