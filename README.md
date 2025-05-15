# Unity HFSM Architecture Example

An example of a hierarchical finite state machine (HFSM) architecture in Unity. Battle tested!

## Battle Tested Games
- [Same Room Same Day](https://store.steampowered.com/app/2888200/Same_Room_Same_Day/) (Windows, MacOS, Steam Deck, Android, iOS, WebGL) — Over 15+ AIs, 4 Big Bosses, over 20-30 states with each AI, main character with 30+ states, main project with 50+ states.
- [My Sweet Street Shop](https://play.google.com/store/apps/details?id=com.bugigamesAndroid.MySweetStreetShop) (Android, iOS) — Restaurant complex simulator, where you can do a lot.
- More games here: [Bugigames.com](https://bugigames.com/)

## Features
- Clean and organized state management.
- Supports nested states and transitions.
- Easily extendable for complex behaviors.
- Flexible for any platform (tested on - Windows, MacOS, Steam Deck, Android, iOS, WebGL)

## Plugins
- [Addressables](https://docs.unity3d.com/Manual/com.unity.addressables.html)
- [Cinemachine](https://docs.unity3d.com/Packages/com.unity.cinemachine@latest)
- [UniTask](https://github.com/Cysharp/UniTask)
- [Zenject](https://github.com/Mathijs-Bakker/Extenject)
- [Odin](https://odininspector.com/)
- [Serializable Dictionary (Self Made)](https://github.com/EduardMalkhasyan/Serializable-Dictionary-Unity)
- [Savable Scriptable Objects (Self Made)](https://github.com/EduardMalkhasyan/Savable-ScriptableObjects-Unity)
- Simple Localization (Self Made)

## For You
Feel free to use any plugin you find in the self-made section of Plugins. Also, take a look at the `Scripts -> Project Tools` and `Scripts -> Extension Methods` sections — there you can find a lot of useful stuff for you

## Full Diagram 

AbstractGameAudioSource
AbstractMainGameState
AbstractPlayerGameState
AddressableLoader
AnimatorExtensions
AudioPlayerPreset
Bootstrap
├── CancellationTokenPool
├── ChooseLanguage
├── GameCursor
├── GameSettings
├── ├── GameSettingsAudio
├── ├── GameSettingsCharacter
├── ├── GameSettingsGraphics
├── ├── GameSettingsLanguage
├── └── SOLoader
├── LevelSettings
├── ├── Level
├── ├── LevelPreset
├── └── SerializableDictionary
├── LocalizationLanguage
├── ├── LocalizationLanguageObserver
├── MainCanvas
├── MainGameStates
├── ├── AbstractMainGameState
├── ├── DebugColor
├── └── StateMachine
├── MainMenuState
├── ├── LevelHolder
├── ├── LevelsState
├── ├── MainMenuWidget
├── ├── PlayerDisabledState
├── ├── PlayerGameStates
├── ├── PrepareGameState
├── ├── SettingsState
├── ├── UIAudioManager
├── ├── UIMainBackground
├── ├── UIScreensController
├── └── VirtualCamera
├── ObjectPool
├── PlayerSetupManager
├── ├── PlayerCameraRotation
├── ├── PlayerInputSystem
├── └── PlayerPositionSetter
CancellationTokenObserverInspector
└── CancellationTokenPool
CancellationTokenPool
CancellationTokenPoolType
ChooseLanguage
CollisionExtensions
CreditCard
DebugColor
DictionaryExtensions
DynamicEnemyAIAbstractState
└── DynamicEnemyAIBehaviour
└── └── EnemyAIStateMachine
DynamicEnemyAIBehaviour
├── DynamicEnemyAIAbstractState
└── EnemyAIStateMachine
└── └── DebugColor
DynamicEnemyAIPatrolState
└── DynamicEnemyAIAbstractState
└── └── DynamicEnemyAIBehaviour
EnemyAIStateMachine
└── DebugColor
EnumExtensions
ExternalDebugObject
FPSEditor
FadeInOut
FindAssemblyTypes
ForceRebuildLayoutExtensions
GameCursor
GameEffectAudioSource
├── AbstractGameAudioSource
├── GameSettings
├── ├── GameSettingsAudio
├── ├── GameSettingsCharacter
├── ├── GameSettingsGraphics
├── ├── GameSettingsLanguage
├── └── SOLoader
└── GameSettingsObserver
GameInitialState
GameLanguage
GameMusicAudioSource
├── AbstractGameAudioSource
├── GameSettings
├── ├── GameSettingsAudio
├── ├── GameSettingsCharacter
├── ├── GameSettingsGraphics
├── ├── GameSettingsLanguage
├── └── SOLoader
└── GameSettingsObserver
GameObjectExtensions
GameSettings
├── GameSettingsAudio
├── └── GameSettingsObserver
├── GameSettingsCharacter
├── GameSettingsGraphics
├── GameSettingsLanguage
└── SOLoader
└── ├── SOLoaderJsonUtility
└── └── SOProps
GameSettingsAudio
└── GameSettingsObserver
GameSettingsCharacter
└── GameSettingsObserver
GameSettingsGraphics
GameSettingsLanguage
GameSettingsObserver
GizmoSphere
Gradient
IEnemyAIBehaviour
IGameInputSystem
IGameState
ISOLoader
InitialSceneLoader
├── GameSettings
├── ├── GameSettingsAudio
├── ├── GameSettingsCharacter
├── ├── GameSettingsGraphics
├── ├── GameSettingsLanguage
├── └── SOLoader
└── WaitLoadingSpinnerDots
InterfaceHolder
└── InterfaceHolderDrawer
InvisibleBlocker
LayerAttribute
LayerAttributeDrawer
└── LayerAttribute
LayerMaskNamesSettings
└── SOLoader
└── ├── SOLoaderJsonUtility
└── └── SOProps
Level
└── CancellationTokenPool
LevelCard
LevelFinish
├── PlayerCollisions
└── PlayerObserver
LevelHolder
├── AddressableLoader
├── Level
├── └── CancellationTokenPool
└── LevelSettings
└── ├── LevelPreset
└── ├── SOLoader
└── └── SerializableDictionary
LevelPreset
LevelSettings
├── Level
├── └── CancellationTokenPool
├── LevelPreset
├── SOLoader
├── ├── SOLoaderJsonUtility
├── └── SOProps
└── SerializableDictionary
└── └── SerializedDictionaryKVPProps
LevelsState
├── AbstractMainGameState
├── LevelSettings
├── ├── Level
├── ├── LevelPreset
├── ├── SOLoader
├── └── SerializableDictionary
├── LevelsWidget
├── └── LevelCard
├── MainGameStates
├── ├── DebugColor
├── └── StateMachine
├── MainInputSystem
├── MainMenuState
├── ├── GameCursor
├── ├── LevelHolder
├── ├── MainMenuWidget
├── ├── PlayerDisabledState
├── ├── PlayerGameStates
├── ├── PrepareGameState
├── ├── SettingsState
├── ├── UIAudioManager
├── ├── UIMainBackground
├── ├── UIScreensController
├── └── VirtualCamera
LevelsWidget
├── Level
├── └── CancellationTokenPool
└── LevelCard
ListExtensions
LocalizationAbstractSceneComponent
LocalizationDataHolder
├── LocalizationLanguage
├── ├── LocalizationLanguageObserver
├── └── SOLoader
└── SerializableDictionary
└── └── SerializedDictionaryKVPProps
LocalizationGameObject
├── LocalizationAbstractSceneComponent
├── LocalizationDataHolder
├── ├── LocalizationLanguage
├── ├── SOLoader
├── └── SerializableDictionary
└── LocalizationLanguageObserver
LocalizationGameObjectType
LocalizationLanguage
├── LocalizationLanguageObserver
└── SOLoader
└── ├── SOLoaderJsonUtility
└── └── SOProps
LocalizationLanguageObserver
LocalizationTMPDropDown
├── LocalizationAbstractSceneComponent
├── LocalizationDataHolder
├── ├── LocalizationLanguage
├── ├── SOLoader
├── └── SerializableDictionary
└── LocalizationLanguageObserver
LocalizationTMPDropdownType
LocalizationTMPText
├── LocalizationAbstractSceneComponent
├── LocalizationDataHolder
├── ├── LocalizationLanguage
├── ├── SOLoader
├── └── SerializableDictionary
└── LocalizationLanguageObserver
LocalizationTMPTextType
MainCanvas
MainGameStates
├── AbstractMainGameState
├── DebugColor
└── StateMachine
MainInputSystem
MainInputSystemMap
└── MainInputSystem
MainMenuState
├── AbstractMainGameState
├── GameCursor
├── LevelHolder
├── ├── AddressableLoader
├── ├── Level
├── └── LevelSettings
├── LevelsState
├── ├── LevelsWidget
├── ├── MainGameStates
├── ├── MainInputSystem
├── ├── PrepareGameState
├── ├── UIMainBackground
├── └── UIScreensController
├── MainMenuWidget
├── PlayerDisabledState
├── ├── AbstractPlayerGameState
├── ├── PlayerActivator
├── └── PlayerInputSystem
├── PlayerGameStates
├── ├── DebugColor
├── └── StateMachine
├── SettingsState
├── ├── GameSettings
├── ├── LocalizationLanguage
├── ├── SettingsWidget
├── UIAudioManager
├── └── AudioPlayerPreset
└── VirtualCamera
└── └── SerializableDictionary
MainMenuWidget
MeshCombiner
MeshCombinerEditor
└── MeshCombiner
MeshRendererDisabler
MinMaxAttribute
MinMaxDrawer
└── MinMaxAttribute
NextLevelState
├── AbstractMainGameState
├── LevelHolder
├── ├── AddressableLoader
├── ├── Level
├── └── LevelSettings
├── MainGameStates
├── ├── DebugColor
├── └── StateMachine
├── PlayerGameStates
├── ├── AbstractPlayerGameState
├── PlayerWaitForNextLevelState
├── ├── PlayerActivator
├── ├── PlayerFirstPersonController
├── └── PlayerInputSystem
└── PrepareGameState
└── ├── FadeInOut
└── ├── PlayGameState
└── ├── PlayerObserver
└── ├── PlayerResetState
└── ├── UIAudioManager
└── ├── UIMainBackground
└── └── WaitLoadingSpinnerDots
NumberExtensions
ObjectPool
PauseState
├── AbstractMainGameState
├── GameCursor
├── MainGameStates
├── ├── DebugColor
├── └── StateMachine
├── MainInputSystem
├── MainMenuState
├── ├── LevelHolder
├── ├── LevelsState
├── ├── MainMenuWidget
├── ├── PlayerDisabledState
├── ├── PlayerGameStates
├── ├── PrepareGameState
├── ├── SettingsState
├── ├── UIAudioManager
├── ├── UIMainBackground
├── ├── UIScreensController
├── └── VirtualCamera
├── PauseWidget
├── PlayGameState
├── ├── PlayerFPSState
├── PlayerPauseState
├── ├── AbstractPlayerGameState
├── ├── PlayerFirstPersonController
├── └── PlayerInputSystem
PauseWidget
PlayGameState
├── AbstractMainGameState
├── MainGameStates
├── ├── DebugColor
├── └── StateMachine
├── MainInputSystem
├── PauseState
├── ├── GameCursor
├── ├── MainMenuState
├── ├── PauseWidget
├── ├── PlayerFPSState
├── ├── PlayerGameStates
├── ├── PlayerPauseState
├── ├── SettingsState
├── ├── UIMainBackground
├── └── UIScreensController
PlayWidget
PlayerActivator
PlayerCameraRotation
├── GameSettings
├── ├── GameSettingsAudio
├── ├── GameSettingsCharacter
├── ├── GameSettingsGraphics
├── ├── GameSettingsLanguage
├── └── SOLoader
├── GameSettingsObserver
└── PlayerInputSystem
PlayerCollisions
PlayerDisabledState
├── AbstractPlayerGameState
├── PlayerActivator
└── PlayerInputSystem
PlayerFPSState
├── AbstractPlayerGameState
├── GameCursor
├── MainGameStates
├── ├── AbstractMainGameState
├── ├── DebugColor
├── └── StateMachine
├── MainInputSystem
├── NextLevelState
├── ├── LevelHolder
├── ├── LevelSettings
├── ├── PlayerGameStates
├── ├── PlayerWaitForNextLevelState
├── └── PrepareGameState
├── PlayerCameraRotation
├── ├── GameSettings
├── ├── GameSettingsObserver
├── └── PlayerInputSystem
├── PlayerFirstPersonController
└── PlayerObserver
PlayerFirstPersonController
└── PlayerInputSystem
PlayerGameStates
├── AbstractPlayerGameState
├── DebugColor
└── StateMachine
PlayerInputSystem
PlayerInputSystemMap
PlayerObserver
PlayerPauseState
├── AbstractPlayerGameState
├── PlayerFirstPersonController
├── └── PlayerInputSystem
PlayerPositionSetter
PlayerResetState
├── AbstractPlayerGameState
├── GameCursor
├── PlayerActivator
├── PlayerCameraRotation
├── ├── GameSettings
├── ├── GameSettingsObserver
├── └── PlayerInputSystem
├── PlayerFirstPersonController
├── PlayerObserver
├── PlayerPositionSetter
└── VirtualCamera
└── └── SerializableDictionary
PlayerSetupManager
├── PlayerCameraRotation
├── ├── GameSettings
├── ├── GameSettingsObserver
├── └── PlayerInputSystem
└── PlayerPositionSetter
PlayerWaitForNextLevelState
├── AbstractPlayerGameState
├── PlayerActivator
├── PlayerFirstPersonController
├── └── PlayerInputSystem
PrepareGameState
├── AbstractMainGameState
├── FadeInOut
├── LevelHolder
├── ├── AddressableLoader
├── ├── Level
├── └── LevelSettings
├── MainGameStates
├── ├── DebugColor
├── └── StateMachine
├── PlayGameState
├── ├── MainInputSystem
├── ├── PauseState
├── ├── PlayerFPSState
├── ├── PlayerGameStates
├── └── UIScreensController
├── PlayerObserver
├── PlayerResetState
├── ├── AbstractPlayerGameState
├── ├── GameCursor
├── ├── PlayerActivator
├── ├── PlayerCameraRotation
├── ├── PlayerFirstPersonController
├── ├── PlayerPositionSetter
├── └── VirtualCamera
├── UIAudioManager
├── └── AudioPlayerPreset
├── UIMainBackground
└── WaitLoadingSpinnerDots
ProjectContextInstaller
└── AddressableLoader
ProjectDebuggerController
├── ExternalDebugObject
├── FPSEditor
├── GameCursor
├── LevelHolder
├── ├── AddressableLoader
├── ├── Level
├── └── LevelSettings
└── ShowFPS
RandomPossibilities
SOCreator
├── SOLoader
├── ├── SOLoaderJsonUtility
├── └── SOProps
SOLoader
├── SOLoaderJsonUtility
├── ├── BoundsConverter
├── ├── BoundsIntConverter
├── ├── Color32Converter
├── ├── ColorConverter
├── ├── GradientConverter
├── ├── LayerMaskConverter
├── ├── QuaternionConverter
├── ├── RectConverter
├── ├── RectIntConverter
├── ├── UnityObjectResolver
├── ├── Vector2Converter
├── ├── Vector2IntConverter
├── ├── Vector3Converter
├── ├── Vector3IntConverter
├── └── Vector4Converter
└── SOProps
SOLoaderConverters
├── BoundsConverter
├── BoundsIntConverter
├── Color32Converter
├── ColorConverter
├── Gradient
├── GradientConverter
├── LayerMaskConverter
├── QuaternionConverter
├── RectConverter
├── RectIntConverter
├── Vector2Converter
├── Vector2IntConverter
├── Vector3Converter
├── Vector3IntConverter
└── Vector4Converter
SOLoaderEditor
└── SOLoader
└── ├── SOLoaderJsonUtility
└── └── SOProps
SOLoaderExtensions
SOLoaderJsonUtility
├── BoundsConverter
├── BoundsIntConverter
├── Color32Converter
├── ColorConverter
├── GradientConverter
├── LayerMaskConverter
├── QuaternionConverter
├── RectConverter
├── RectIntConverter
├── UnityObjectResolver
├── Vector2Converter
├── Vector2IntConverter
├── Vector3Converter
├── Vector3IntConverter
└── Vector4Converter
SOProps
SceneContextInstaller
├── AbstractMainGameState
├── AbstractPlayerGameState
└── FindAssemblyTypes
ScriptableRendererExtensions
SerializableDictionary
└── SerializedDictionaryKVPProps
SerializableDictionaryDrawer
├── InterfaceHolder
├── └── InterfaceHolderDrawer
└── SerializableDictionary
└── └── SerializedDictionaryKVPProps
SettingsState
├── AbstractMainGameState
├── GameSettings
├── ├── GameSettingsAudio
├── ├── GameSettingsCharacter
├── ├── GameSettingsGraphics
├── ├── GameSettingsLanguage
├── └── SOLoader
├── LocalizationLanguage
├── ├── LocalizationLanguageObserver
├── MainGameStates
├── ├── DebugColor
├── └── StateMachine
├── MainInputSystem
├── SettingsWidget
├── UIMainBackground
└── UIScreensController
└── ├── SerializableDictionary
└── └── UIScreen
SettingsWidget
ShowFPS
SoundButton
└── UIAudioManager
└── └── AudioPlayerPreset
SoundDropdown
└── UIAudioManager
└── └── AudioPlayerPreset
SoundToggle
└── UIAudioManager
└── └── AudioPlayerPreset
StateMachine
UIAudioManager
└── AudioPlayerPreset
UIExtensions
UIMainBackground
UIScreen
└── UISettings
└── └── SOLoader
UIScreenEnum
UIScreensController
├── SerializableDictionary
├── └── SerializedDictionaryKVPProps
└── UIScreen
└── └── UISettings
UISettings
└── SOLoader
└── ├── SOLoaderJsonUtility
└── └── SOProps
UnityObjectResolver
VectorExtensions
VirtualCamera
└── SerializableDictionary
└── └── SerializedDictionaryKVPProps
VirtualCameraType
VolumeExtensions
WaitLoadingSpinnerDots
Wrappers
└── UnityObjectWrapper



