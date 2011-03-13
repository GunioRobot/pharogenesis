emailPackageMaintainers
	"Send mail to package owner and co-maintainers."

	| item package toAddresses |
	item := self selectedPackageOrRelease.
	package := item isPackageRelease ifTrue: [item package] ifFalse: [item].

	"(this logic should be moved to MailMessage as soon as it can handle 
multiple To: addresses)"
	toAddresses := '<', package owner email, '>'.
	package maintainers ifNotNil: [
		package maintainers do: [:maintainer |
			toAddresses := toAddresses, ', <', maintainer email, '>']].

	SMUtilities sendMailTo: toAddresses regardingPackageRelease: item