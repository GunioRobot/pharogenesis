streamOn: collection upToAll: subcollection1 upToAll: subcollection2

	^(ReadStream on: collection)
		upToAll: subcollection1;
		upToAll: subcollection2