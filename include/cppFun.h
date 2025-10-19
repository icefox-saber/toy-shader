#pragma once

#include <string>
#include <filesystem>
#include <fstream>
#include <iostream>

template <typename DestT>
DestT ReadFile(const std::filesystem::path& filePath);

template<>
std::string ReadFile<std::string>(const std::filesystem::path& filePath);