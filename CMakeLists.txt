cmake_minimum_required(VERSION 3.10)
project(MyOpenGLProject)

set(CMAKE_CXX_STANDARD 17)
add_compile_options(
/source-charset:utf-8 # 源文件本身的编码
/execution-charset:utf-8 # 编译后使用的编码
)
#  将 glad 添加为子目录。
add_subdirectory(${CMAKE_CURRENT_SOURCE_DIR}/glm glm)
add_subdirectory(${CMAKE_CURRENT_SOURCE_DIR}/glfw glfw)
add_subdirectory(${CMAKE_CURRENT_SOURCE_DIR}/assimp assimp)

# 移动资源文件夹Resources到项目根目录
set(RESOURCE_DIR "${CMAKE_SOURCE_DIR}/resources")
file(COPY ${RESOURCE_DIR} DESTINATION ${CMAKE_CURRENT_BINARY_DIR})
file(COPY ${RESOURCE_DIR} DESTINATION ${CMAKE_CURRENT_BINARY_DIR}/Debug)

include_directories(
    ${CMAKE_CURRENT_SOURCE_DIR}/include # 添加项目头文件路径
    ${CMAKE_CURRENT_SOURCE_DIR}/assimp/contrib/stb
)


file(GLOB SRC_FILES src/*.cpp src/*.c)
add_executable(MyOpenGLApp ${SRC_FILES})

target_link_libraries(MyOpenGLApp
    glfw
    glm
    assimp
)