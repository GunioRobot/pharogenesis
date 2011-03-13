markInstalled: uuid version: version time: time counter: num
	"Private. Mark the installation. SM2 uses an Association
	to distinguish the automatic version from old versions."

	^self registry markInstalled: uuid version: version time: time counter: num