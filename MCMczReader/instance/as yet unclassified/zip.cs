zip
	zip ifNil:
		[zip _ ZipArchive new.
		zip readFrom: stream].
	^ zip