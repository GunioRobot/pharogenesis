lastModTime
	"Return my last modification date/time stamp,
	converted to Squeak seconds"

	^self unixToSqueakTime: (self dosToUnixTime: lastModFileDateTime)