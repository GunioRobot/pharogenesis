deleteOldSqueakLogo
(World submorphs
		select: [:each | each externalName = 'SqueakLogo'])
		do: [:each | 
			each delete]