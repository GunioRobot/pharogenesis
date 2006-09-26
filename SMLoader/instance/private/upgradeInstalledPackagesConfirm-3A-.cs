upgradeInstalledPackagesConfirm: confirmEach
	"Tries to upgrade all installed packages to the latest published release for this
	version of Squeak. If confirmEach is true we ask for every upgrade."

	| installed old myRelease toUpgrade info |
	installed := model installedPackages.
	old := model oldPackages.
	old isEmpty ifTrue: [
			^self inform: 'All ', installed size printString, ' installed packages are up to date.'].
	toUpgrade := model upgradeableAndOldPackages.
	toUpgrade isEmpty ifTrue: [
			^self inform: 'None of the ', old size printString, ' old packages of the ', installed size printString, ' installed can be automatically upgraded. You need to upgrade them manually.'].
	old size < toUpgrade size ifTrue: [
		info := 'Of the ', old size printString, ' old packages only ', toUpgrade size printString, ' can be upgraded.
The following packages will not be upgraded:
',  (String streamContents: [:s | (old removeAll: toUpgrade; yourself)
	do: [:p | s nextPutAll: p nameWithVersionLabel; cr]])]
		ifFalse: [info := 'All old packages upgradeable.'].
	(self confirm: info, '
About to upgrade the following packages:
', (String streamContents: [:s | toUpgrade do: [:p | s nextPutAll: p nameWithVersionLabel; cr]]), 'Proceed?') ifTrue: [
			myRelease := self installedReleaseOfMe.
			[Cursor wait showWhile: [
				confirmEach ifTrue: [
					model upgradeOldPackagesConfirmBlock: [:p |
						self confirm: 'Upgrade ', p installedRelease packageNameWithVersion, ' to ',
							(p lastPublishedReleaseForCurrentSystemVersionNewerThan: p installedRelease) listName, '?']]
						ifFalse: [model upgradeOldPackages].
				self inform: toUpgrade size printString, ' packages successfully processed.'.
				myRelease = self installedReleaseOfMe
					ifFalse: [self reOpen]
					ifTrue: [self noteChanged]]
			] on: Error do: [:ex |
				self informException: ex msg: ('Error occurred when upgrading old packages:\', ex messageText, '\') withCRs]]