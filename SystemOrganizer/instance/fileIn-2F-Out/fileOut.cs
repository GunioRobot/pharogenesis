fileOut  "SystemOrganization fileOut"

	(FileStream newFileNamed:
		(FileDirectory default nextNameFor: 'SystemOrganization' extension: 'st'))
		nextPutAll: 'SystemOrganization changeFromCategorySpecs: #('; cr;
		print: SystemOrganization;  "ends with a cr"
		nextPutAll: ')!'; cr;
		close.