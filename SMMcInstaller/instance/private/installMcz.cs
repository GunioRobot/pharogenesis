installMcz
	"Install the package, we already know that either MCInstaller or Monticello is available."

	| installer monticello |
	installer := MczInstaller.
	(Smalltalk hasClassNamed: #MCMczReader) ifFalse: [
		packageRelease package isInstalled ifTrue: [
			(self silent ifFalse: [
				(self confirm:
'A release of package ''', packageRelease package name, ''' is already installed.
You only have MCInstaller and not Monticello
installed and MCInstaller can not properly upgrade packages.
Do you wish to install Monticello first and then proceed?
If you answer no MCInstaller will be used - but at your own risk.
Cancel cancels the installation.' orCancel: [self error: 'Installation cancelled.'])]
			ifTrue: [false])
				ifTrue: [
					monticello := packageRelease map packageWithName: 'Monticello'.
					monticello lastPublishedRelease
						ifNotNil: [monticello lastPublishedRelease install]
						ifNil: [monticello lastRelease install].
					installer := (Smalltalk at: #MCMczReader)]]
	] ifTrue: [installer := (Smalltalk at: #MCMczReader)].
	installer loadVersionFile: self fullFileName