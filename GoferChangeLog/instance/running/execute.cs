execute
	| currentVersion versions |
	latestVersions keysAndValuesDo: [:wc :targetVersion | 
			currentVersion := wc ancestors first.
			currentVersion = targetVersion 
				ifFalse: [
					self cr; logCR: 'Change log for: ', currentVersion name.
					self logCR: '--------------------------------------------------------------------------------------------------'.
					versions := self allVersionsFrom: currentVersion to: targetVersion.
					versions isNil
						ifTrue: [self logCR: '*** Warning: The current version is not included in the ancestry path of the latest version ***']
						ifFalse: [
							versions
								do: [:each | 
									self
										log: each name;
										logCR: (' [', each timeString, ']');
										logIndent: each message] ].
					self logCR: '--------------------------------------------------------------------------------------------------' ] ]