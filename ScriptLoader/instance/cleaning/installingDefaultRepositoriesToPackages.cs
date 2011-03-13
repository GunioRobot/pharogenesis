installingDefaultRepositoriesToPackages
	"self new installingDefaultRepositoriesToPackages"
	
	self installInBoxAnd39.
	self packagesAndHome do: [:each | 
								self installRepository: each second for: each first].