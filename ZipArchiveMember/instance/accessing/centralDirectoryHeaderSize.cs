centralDirectoryHeaderSize

	| systemFileName systemFileComment systemCdExtraField |
	systemFileName _ fileName asVmPathName.
	systemFileComment _ fileComment convertToSystemString.
	systemCdExtraField _ cdExtraField.
	^ 46 + systemFileName size + systemCdExtraField size + systemFileComment size
