clearPackageCache
	| dir |
	dir _ MCCacheRepository default directory.
	(dir fileNamesMatching: 'MonticelloMocks*') do: [:ea | dir deleteFileNamed: ea].
	(dir fileNamesMatching: 'MonticelloTest*') do: [:ea | dir deleteFileNamed: ea].
	(dir fileNamesMatching: 'rev*') do: [:ea | dir deleteFileNamed: ea].