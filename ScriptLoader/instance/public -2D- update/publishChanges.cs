publishChanges
	| username password changescriptname changesetFilename|
	username := UIManager default request: 'Pharo repository login'.
	password := UIManager default requestPassword: 'Pharo repository password'.
	self setToRepositoriesPassword: password to: username.
	
	changescriptname := UIManager default request: 'Changeset name (no space)' initialAnswer: 'WhatAsChanged'.
	changesetFilename := self CSForLastUpdateAndPatchUpdatesList: changescriptname.
	self copyPackagesFromWaitingFolderToHomeRepository.
	self announceOnMailingList.
	self inform: 'All packages have been uploaded to the Pharo repository.
Remaining manual steps:
1) ./upFiles ',changesetFilename,'
2) ./upFiles updates.list
3) Announce new update on mailing list'