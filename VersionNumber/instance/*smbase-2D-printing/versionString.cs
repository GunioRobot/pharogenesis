versionString

	^String streamContents: [ :strm | self versionStringOn: strm ]