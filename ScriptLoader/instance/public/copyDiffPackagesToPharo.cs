copyDiffPackagesToPharo
	"Copy the clean packages that may have been loaded by a slice but are not yet in pharo repository"
	"self new copyDiffPackagesToPharo"
	"self new diffPackages"
	

	| s man r |
	s := Set new.
	man := MCWorkingCopy allManagers.
	Transcript show: '=========================================================================';cr.
	Transcript show: self diffPackages ;cr.
	self diffPackages do: 
		[:packName | 
			r := man select: [:package |  packName, '*' match: package ancestry ancestorString].
			r isEmpty ifFalse: [s add: r first]].
	s do: [:wc | 
			self repository storeVersion: wc newVersion.].
		
	