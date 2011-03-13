servicesHelpText
	^ '
	This is an overview of the main concepts of the services framework. More details are available in class comments. The aim is to help you defining services step by step. The three main classes are: 

-ServiceAction
-ServiceCategory
-ServiceProvider

Alongside them, a tool to use is the Services Browser. It can be found in the world menu, under the ''Preferences & Services'' menu heading (in which you found this text).
	
	ServiceAction are executable objects in various contexts.
They can be displayed as buttons or menu items or bounded to keyboard shortcuts.

	ServiceCategory are categories of services. They are also services, so a ServiceCategory can be included in another, forming a tree of Services. ServiceCategories can be displayed with menus, or button bars.
	
	A ServiceProvider references services that are relevant to a given application.
Each application that wishes to use the Services framework must subclass a ServiceProvider.
This class must define a ''services'' method category.
Each method implemented in this category will be automatically called by the framework.
Each of these method should be a unary message (taking no argument), and return a fully initialised instance of ServiceAction or ServiceCategory. There are three possible patterns:

1)
serviceIdentifierAndMethodName
	^ ServiceAction
		text: ''Menu item text''
		button:''Button text''
		description: ''Longer text that appears in help balloons''
		action: [:r | "Code block fetching data from the requestor instance, r, that is passed to the block"]
		
2)
serviceIdentifierAndMethodName
	^ ServiceAction
		text: ''Menu item text''
		button: ''Button text''
		description: ''Longer text that appears in help balloons''
		action: [:r | "Code block fetching data from the requestor instance, r, that is passed to the block"]
		condition: [:r | "second block returning true if the service can be used at the time being, false otherwise. Data can still be fetched from the requestor instance"]
		
3)
methodNameAndServiceCategoryId
	^ ServiceCategory 
		text: ''Menu text''
		button: ''Button  text'' 
		description: ''Longer descriptive text appearing in help balloons''

The block given to the ServiceActions can take an instance of the Requestor class as parameter. You can fetch data from these. The generic format is to call methods starting with ''get'' on the requestor, like getClass, getMessageName for services related to the browser.	

The organisation of services into categories, and the services bound to keyboard shortcuts are
specified using the Services Browser, based on the Preference Browser by Hernan Tylim. When editing preferences, they are saved as methods on the ServiceProvider, all defined in the ''saved preferences'' method category. 

When opening the Services Browser you see a list of preference categories on the left, and the preferences inside this category on the right. The main preference categories for services are: 

-- keyboard shortcuts -- : several text preferences, one per keyboard shortcuts. To edit them,  enter a service identifier (equal to the method name under which it is defined in its ServiceProvider), and accept with alt-s or enter

-- menu contents -- : All the service categories in the image have a text preference under here. To edit it, enter the services identifiers you wish to put in this category, separating them with a single space character. The order is important: it defines the order of the items in menus.

-- settings -- : general boolean preferences.

Then there is a preference category for each provider in the image. Under each, you will find:
A boolean preference for each service in the image. If it is false, the service will not appear in menus. 
The text preference for each service category defined by the service provider. This is the same as the one appearing in the menu contents preference category.

Some identifiers of categories already appearing in the UI are:
- world : the world menu
- preferencesMenu
- browserClasssCategoryMenu
- browserClassMenu
- browserMethodCategoryMenu
- browserMethodMenu
- browserCodePaneMenu
- browserButtonBar

After editing these preferences to match the services and categories you defined for your application, you should be done.

	Romain Robbes'