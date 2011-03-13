installAsCurrent: anInstance
	self flag: #deferred.
	currentDataInstance _ anInstance.
	"aList _ self world allViewersOn: currentDataInstance."
	anInstance costume: self.
	costumee _ anInstance.
	self morphsForInstanceData do:
			[:m | m dockUpToInstance: anInstance].
"	aList do:
		[:aViewer |  ... remove it, or install the new instance into it."
