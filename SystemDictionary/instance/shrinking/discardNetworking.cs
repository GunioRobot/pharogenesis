discardNetworking
	"Discard the support for TCP/IP networking."

	Smalltalk discardPluggableWebServer.
	SystemOrganization removeCategoriesMatching: 'Network-*'.

