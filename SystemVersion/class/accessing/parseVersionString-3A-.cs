parseVersionString: versionString
	"Answer the version of this release as version, date, update."
	"SystemVersion parseVersionString: 'Squeak3.1alpha of 28 February 2001 [latest update: #3966]' "

	| stream version date update |

	[stream _ ReadStream on: versionString.
	version _ stream upToAll: ' of '.
	date _ Date readFrom: stream.
	stream upToAll: ' #'.
	update _ Number readFrom: stream]
		on: Error
		do: [^nil].
	^{version. date. update.}