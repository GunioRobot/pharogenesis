newRelease
	"Create a new release. Just use the last
	chronological release as parent, if this is the first release
	that is nil."

	^self newChildReleaseFrom: self lastRelease